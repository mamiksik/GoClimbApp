import {Component} from "@angular/core";
import {RouterExtensions} from "nativescript-angular/router";

//DI
import {AuthService} from "../../Services/auth.service";
//import {RouterExtensions} from "../../Services/router-extensions.service";

@Component({
	selector: "app",
	template: `<page-router-outlet></page-router-outlet>`
})
export class AppComponent
{

	constructor(private routerExt: RouterExtensions, private authService: AuthService)
	{}

	ngOnInit()
	{
		if(!this.authService.isLoggedIn()) {
			this.routerExt.navigate(['login'], { clearHistory: true, animated: false});
		} else {
			this.routerExt.navigate(['user-detail'], { clearHistory: true});
		}
	}
}


