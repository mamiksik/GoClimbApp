export class Utils
{
	static getQueryParameter(field: string, query: string)
	{
		let reg = new RegExp( '[?&]' + field + '=([^&#]*)', 'i' );
		let string = reg.exec(query);
		return string ? string[1] : null;
	}
}
