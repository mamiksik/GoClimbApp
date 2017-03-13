import {Component} from "@angular/core";
import {AuthService} from "../../Services/auth.service";
import {UserFacade} from "../../Model/Facade/UserFacade";
import {Observable} from "rxjs";
import {User} from "../../Model/Entities/User";


@Component({
	moduleId: module.id,
	selector: "user-detail",
	templateUrl: "./user-detail.component.tns.html"
})
export class UserDetailComponent
{
	user;
	userTest = 'Var Test';

	constructor(private authService: AuthService, private userFacade: UserFacade)
	{}

	ngOnInit()
	{
		console.log('Detail');

		this.userFacade.getUser(this.authService.getUserId()).subscribe(
			user => this.user = user,
			error => console.error('Error: ' + error),
        	() => console.log('Completed!')
		);

		// console.dump(this.user);
		// this.userFacade.getUser(this.authService.getUserId()).subscribe((user) => {
		// 	console.log(user.name);
		// 	this.user = user;
		// 	console.log(this.user.name);
		// });
	}

	loadTap()
	{
		console.log(this.user);
		console.log(this.user.name);
		console.log(this.user instanceof User);
	}
}


