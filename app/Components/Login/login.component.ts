//Angular
import {Component} from "@angular/core";

//Utils
import {openUrl} from "utils/utils";
import config from "../../config";

//DI
import {AuthService} from "../../Services/auth.service";

@Component({
	moduleId: module.id,
	selector: "login",
	templateUrl: "./login.component.tns.html"
})

export class LoginComponent
{
	constructor(public authService: AuthService)
	{
		console.log(this.authService.isLoggedIn())
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
