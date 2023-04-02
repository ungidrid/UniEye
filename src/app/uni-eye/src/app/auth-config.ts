
import {
  LogLevel,
  Configuration,
  BrowserCacheLocation,
  IPublicClientApplication,
  PublicClientApplication, InteractionType
} from '@azure/msal-browser';
import {MsalGuardConfiguration} from '@azure/msal-angular';

export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication(msalConfig);
}

export function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
    authRequest: loginRequest
  };
}

const msalConfig: Configuration = {
  auth: {
    clientId: '22b49c3c-cc10-483e-a07e-a281d5ec430f',
    authority: 'https://login.microsoftonline.com/2c6b61e9-a9be-49ab-a48a-78863332d8e0',
    redirectUri: '/auth',
    postLogoutRedirectUri: '/',
    clientCapabilities: ['CP1']
  },
  cache: {
    cacheLocation: BrowserCacheLocation.LocalStorage
  },
  system: {
    loggerOptions: {
      loggerCallback(logLevel: LogLevel, message: string) {
        console.log(message);
      },
      logLevel: LogLevel.Verbose,
      piiLoggingEnabled: false
    }
  }
}

const loginRequest = {
  scopes: ["api://b01cf529-2bb7-4f61-937f-ab5e45b74c7c/UniEye.Access"]
};
