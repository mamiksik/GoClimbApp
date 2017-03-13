//Angular
import {Injectable} from '@angular/core';
import {Http} from "@angular/http";

import 'rxjs/add/operator/map';

import config from "../../config";

//DI
import {HttpService} from "../Http/HttpService";


@Injectable()
export class UserFacade
{
	constructor(private httpService: HttpService)
	{}

	getUser(id: number)
	{
		return this.httpService.get('/users/' + id).map(response => response.user);
	}
}
