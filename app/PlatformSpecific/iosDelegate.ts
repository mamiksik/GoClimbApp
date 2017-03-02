import {AuthService} from "../Services/auth.service";
import {Utils} from "../Utils/Utils";

export class iOSDelegate extends UIResponder implements UIApplicationDelegate
{

	private static lock: boolean = false;
	private static authService: AuthService;

	static ObjCProtocols = [UIApplicationDelegate];

	static injectComponents(authService: AuthService)
	{
		if (!iOSDelegate.lock) {
			iOSDelegate.authService = authService;
			iOSDelegate.lock = true;
		} else {
			console.log('Components already injected into delegate');
		}
	}

	applicationOpenURLSourceApplicationAnnotation(application: UIApplication, url: NSURL, sourceApplication: string, annotation: any): boolean
	{
		if (url.absoluteString){
			let token = Utils.getQueryParameter('login_token', url.absoluteString);
			console.log(token);
			if (token) {
				iOSDelegate.authService.logIn(token);
			}
			return true
		}

		return false;
	}
}
