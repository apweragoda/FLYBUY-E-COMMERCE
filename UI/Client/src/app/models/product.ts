import { IProductStock } from "./productStock";

export interface IProduct {
  id: number;
  name: string;
  image: string;
  price: number;
  category: string;
  description: string;
  productStock: IProductStock[];
}
