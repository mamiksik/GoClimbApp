//Angular
import {Component} from "@angular/core";

//Utils
import {openUrl} from "utils/utils";
import config from "../../config";

//DI
import {AuthService} from "../../Services/auth.service";
import {RouterExtensions} from "nativescript-angular/router";

@Component({
	moduleId: module.id,
	selector: "login",
	templateUrl: "./login.component.tns.html"
})

export class LoginComponent
{
	constructor(public authService: AuthService, private routerExt: RouterExtensions)
	{
		if(this.authService.isLoggedIn()){
			this.routerExt.navigate(['user-detail'], { clearHistory: true});
		}
	}

	tapLogin()
	{
		openUrl(config.AUTH_URL);
	}

	getInfo()
	{
		console.log(this.authService.isLoggedIn());
	}
}
