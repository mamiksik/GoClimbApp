// angular
import {Injectable} from '@angular/core';
import * as appSettings from "application-settings";

@Injectable()
export class AuthService
{
	private TOKEN: string = 'LOGIN_TOKEN';

	logIn(token: string)
	{
		console.log(token);
		appSettings.setString(this.TOKEN, token);
	}

	isLoggedIn()
	{
		if (appSettings.getString(this.TOKEN)){
			return true
		} else {
			return false;
		}
	}

}
