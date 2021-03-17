export interface ProductSearchModel {
	by: string;
	keyword?: string;
	limit: number;
	newest?: number;
	order: string;
	page_type: string;
}