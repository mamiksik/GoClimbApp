// angular
import {Injectable} from '@angular/core';
import * as appSettings from "application-settings";
import {UserFacade} from "../Model/Facade/UserFacade";
import {User} from "../Model/Entities/User";
import {Observable} from "rxjs";
import {Http} from "@angular/http";
import config from "../config";

@Injectable()
export class AuthService
{
	private restToken: Observable<string> = null;

	private readonly LOGIN_TOKEN: string = 'LOGIN_TOKEN';
	private readonly USER_ID: string = 'USER_ID';

	constructor(private http: Http)
	{
	}

	logIn(userId: number, token: string)
	{
		appSettings.setNumber(this.USER_ID, userId);
		appSettings.setString(this.LOGIN_TOKEN, token);

		this.getRestToken(true);
	}


	getRestToken(refresh = false): Observable<string>
	{
		if(!this.restToken || refresh == true) {
			this.restToken = this.http.get(config.GET_AUTH_TOKEN_URL + this.getLoginToken()).map(res => res.json().data.restToken);
		}

		return this.restToken;
	}


	isLoggedIn(): boolean
	{
		if (this.getLoginToken()) {
			return true
		} else {
			return false;
		}
	}

	getUserId(): number
	{
		return appSettings.getNumber(this.USER_ID)
	}

	private getLoginToken(): string
	{
		return appSettings.getString(this.LOGIN_TOKEN);
	}
}
