import {Component, transition} from "@angular/core";

import {UserService} from "../../Services/user.service";
import {RouterExtensions} from "nativescript-angular";





@Component({
	selector: "app",
	template: `<page-router-outlet></page-router-outlet>`
})
export class AppComponent
{

	constructor(private routerExt: RouterExtensions, private userService: UserService)
	{
	}

	ngOnInit()
	{
		if(!this.userService.isLoggedIn()) {
			this.routerExt.navigate(['login'], { clearHistory: true, animated: false});
		}
	}
}


