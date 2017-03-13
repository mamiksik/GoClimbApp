//Angular
import {Injectable} from '@angular/core';
import {Http} from "@angular/http";

import config from "../../config";

//DI
import {AuthService} from "../../Services/auth.service";

import 'rxjs/add/operator/map';
import {Observable} from "rxjs";



@Injectable()
export class HttpService
{
	constructor(private http: Http, private authService: AuthService)
	{}

	get(request: string)
	{
		let url = this.createUrl(request);
		let data = this.http.get(url).map(response => response = response.json().data).catch((error: any) => {
				return this.authService.getRestToken(true).flatMap(() => {
					console.error('Refresh Rest Token');
					return this.get(request)
				});
			});


		return data;
	}

	private createUrl(apiLocation: string): string
	{
		console.log(this.authService.getRestToken());
		return config.API_URL + apiLocation + '?token=' + this.authService.getRestToken();
	}
}
