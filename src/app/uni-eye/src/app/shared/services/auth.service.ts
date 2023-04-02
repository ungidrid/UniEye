import {Inject, Injectable} from '@angular/core';
import {BehaviorSubject, filter, Observable, Subject, takeUntil} from 'rxjs';
import {MSAL_GUARD_CONFIG, MsalBroadcastService, MsalGuardConfiguration, MsalService} from '@azure/msal-angular';
import {EventMessage, EventType, InteractionStatus, RedirectRequest} from '@azure/msal-browser';

@Injectable({providedIn: 'root'})
export class AuthService {
  public isLoggedIn$: Observable<boolean>;
  private isLoggedInSubject$: Subject<boolean>;

  constructor(
    @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private authService: MsalService,
    private msalBroadcastService: MsalBroadcastService
  ) {
    this.isLoggedInSubject$ = new BehaviorSubject<boolean>(false);
    this.isLoggedIn$ = this.isLoggedInSubject$.asObservable();

    this.subscribeToAccountChanges();
    this.subscribeToInteractionStatusChanges();
    this.setLoginDisplay();
  }

  public login() {
    const authRequest = this.msalGuardConfig.authRequest;
    const loginRedirectArgs = authRequest && {...authRequest } as RedirectRequest;
    this.authService.loginRedirect(loginRedirectArgs);
  }

  public logout() {
    const activeAccount = this.authService.instance.getActiveAccount() || this.authService.instance.getAllAccounts()[0];
    this.authService.logoutRedirect({
      account: activeAccount
    });
  }

  private setLoginDisplay() {
    const isLoggedIn = this.authService.instance.getAllAccounts().length > 0;
    this.isLoggedInSubject$.next(isLoggedIn);
  }

  private checkAndSetActiveAccount() {
    let activeAccount = this.authService.instance.getActiveAccount();

    if (!activeAccount && this.authService.instance.getAllAccounts().length > 0) {
      let accounts = this.authService.instance.getAllAccounts();
      this.authService.instance.setActiveAccount(accounts[0]);
    }
  }

  private subscribeToInteractionStatusChanges() {
    this.msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
      )
      .subscribe(() => {
        this.setLoginDisplay();
        this.checkAndSetActiveAccount();
      });
  }

  private subscribeToAccountChanges() {
    this.authService.instance.enableAccountStorageEvents();

    this.msalBroadcastService.msalSubject$
      .pipe(
        filter((msg: EventMessage) => msg.eventType === EventType.ACCOUNT_ADDED || msg.eventType === EventType.ACCOUNT_REMOVED),
      )
      .subscribe((result: EventMessage) => {
        if (this.authService.instance.getAllAccounts().length === 0) {
          window.location.pathname = "/";
        } else {
          this.setLoginDisplay();
        }
      });
  }
}
