import React, { useState } from "react";
import ProductForm from "./ProductForm";
import { Button } from "reactstrap";

const newProduct = {
  id: "0",
  name: "",
  description: "",
  price: "",
  productType: {
    id: 1,
    name: "",
  },
};

const AddProduct = (props) => {
  const [product, setProduct] = useState(newProduct);

  const saveHandler = () => {
    props.onSubmit(product);
  };

  return (
    <React.Fragment>
      <h3>New Product</h3>
      <ProductForm
        product={product}
        productTypes={props.productTypes}
        setProduct={setProduct}
      />
      <Button onClick={saveHandler} color="success">
        Save
      </Button>
    </React.Fragment>
  );
};

export default AddProduct;
