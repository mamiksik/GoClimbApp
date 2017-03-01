import {Component} from "@angular/core";
import {Page} from "ui/page";
import {openUrl} from "utils/utils";
import config from "../../config";

@Component({
	moduleId: module.id,
	selector: "login",
	templateUrl: "./login.component.tns.html"
})

export class LoginComponent
{
	constructor()
	{

	}

	tapLogin()
	{
		openUrl(config.AUTH_URL);
	}
}
