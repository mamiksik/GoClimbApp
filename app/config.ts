class ProjectConfig
{
	APP_NAME: string = 'GoTrack';

	API_URL: string = '';

	// AUTH_URL: string = 'http://localhost/GoClimb/www/auth';
	AUTH_URL: string = 'http://localhost/GoClimb/www/auth/cs/admin/login?back=http%3A%2F%2Flocalhost%2FGoClimb%2Fwww%2Fadmin%2Fcs%2F%3FloginToken%3D__TOKEN__';
}
const config: ProjectConfig = new ProjectConfig();
export default config;
