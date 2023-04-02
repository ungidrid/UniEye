import {Component, OnInit} from '@angular/core';
import {TestHttpService} from './shared/services/test-http.service';
import {AuthService} from './shared/services/auth.service';
import {filter, switchMap} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'uni-eye';

  constructor(private testHttpService: TestHttpService, private authService: AuthService) {
  }

  ngOnInit(): void {
    this.authService.isLoggedIn$
      .pipe(
        filter(x => x),
        switchMap(_ => this.testHttpService.sendTestRequest())
      )
      .subscribe(res => console.log(res));
  }
}
