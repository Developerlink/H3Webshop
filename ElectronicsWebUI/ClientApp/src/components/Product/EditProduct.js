import React, { useState } from "react";
import ProductForm from "./ProductForm";
import { useState } from "react";

const EditProduct = (props) => {
    const [product, setProduct] = useState();
  return <ProductForm
  product={selectedProduct}
  productTypes={productTypes}
  onUpdate={updateProductHandler}
  onDelete={deleteProductHandler}
/>;
};

export default EditProduct;
