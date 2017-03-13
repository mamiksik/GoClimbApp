//Angular
import {NgModule, NO_ERRORS_SCHEMA} from "@angular/core";

//Typescript
import {platformNativeScriptDynamic} from "nativescript-angular/platform";
import {NativeScriptModule} from "nativescript-angular/nativescript.module";
import {NativeScriptRouterModule, NativeScriptHttpModule} from "nativescript-angular";

//Bootstrap
import {AppComponent} from "./Components/App/app.component";

//Providers
import {Services} from "./Services/services";

//Components
import {Components} from "./Components/components";
import {ComponentsRoutes} from "./Components/routes";

//Platform specific
import * as application from 'application';
import {iOSDelegate} from "./PlatformSpecific/iosDelegate";

//DI
import {AuthService} from "./Services/auth.service";

@NgModule({
	bootstrap: [AppComponent],
	schemas: [NO_ERRORS_SCHEMA],
	declarations: [
		...<any>Components
	],
	imports: [
		NativeScriptHttpModule,
		NativeScriptModule,
		NativeScriptRouterModule,
		NativeScriptRouterModule.forRoot(ComponentsRoutes)
	],
	providers: [
		...<any>Services
	]
})

export class AppModule
{
	constructor(authSevice: AuthService){
		if(application.ios) {
			//Inject DI components as static to delegate, I think it is easiest way.
			iOSDelegate.injectComponents(authSevice);
		}
	}
}

//Bind platform specific delegate to application
if(application.ios) {
	application.ios.delegate = iOSDelegate;
}

platformNativeScriptDynamic().bootstrapModule(AppModule);
