import {Routes} from "@angular/router";

import {AppRoute} from "./App/app.routes";
import {LoginRoute} from "./Login/login.routes";
import {UserDetailRoute} from "./UserDetail/user-detail.routes";

export const ComponentsRoutes: Routes = [
	AppRoute,
	LoginRoute,
	UserDetailRoute
];
