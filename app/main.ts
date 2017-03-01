import {NgModule, NO_ERRORS_SCHEMA} from "@angular/core";

import {platformNativeScriptDynamic} from "nativescript-angular/platform";
import {NativeScriptModule} from "nativescript-angular/nativescript.module";
import {NativeScriptRouterModule, RouterExtensions} from "nativescript-angular";

import {AppComponent} from "./Components/App/app.component";
import {Components} from "./Components/components";
import {ComponentsRoutes} from "./Components/routes";
import {Services} from "./Services/services";

import * as application from 'application';

@NgModule({
	bootstrap: [AppComponent],
	schemas: [NO_ERRORS_SCHEMA],
	declarations: [
		...<any>Components
	],
	imports: [
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
}





class MyDelegate extends UIResponder implements UIApplicationDelegate {
	public static ObjCProtocols = [UIApplicationDelegate];

	applicationOpenURLSourceApplicationAnnotation(application: UIApplication, url: NSURL, sourceApplication: string, annotation: any): boolean {
		console.log(url.absoluteString);
		console.log(url.filePathURL.absoluteString);
		return url.absoluteString == 'GoTrackApp';
	}
}

application.ios.delegate = MyDelegate;
platformNativeScriptDynamic().bootstrapModule(AppModule);
