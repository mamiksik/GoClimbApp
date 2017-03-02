import {Component} from "@angular/core";
import {RouterExtensions} from "nativescript-angular";

//DI
import {AuthService} from "../../Services/auth.service";

@Component({
	selector: "app",
	template: `<page-router-outlet></page-router-outlet>`
})
export class AppComponent
{

	constructor(private routerExt: RouterExtensions, private authService: AuthService)
	{
	}

	ngOnInit()
	{
		if(!this.authService.isLoggedIn()) {
			this.routerExt.navigate(['login'], { clearHistory: true, animated: false});
		}
	}
}


