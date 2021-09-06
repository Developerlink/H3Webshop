import React, { useState, useEffect } from "react";
import ProductForm from "./ProductForm";
import { Button } from "reactstrap";

const emptyProduct = {
  id: 0,
  name: "",
  description: "",
  price: "",
  productType: {
    id: 1,
    name: "",
  },
};

const EditProduct = (props) => {
  const [product, setProduct] = useState(emptyProduct);

  useEffect(() => {
    if (props.product) {
      setProduct(props.product);
    } else {
      //console.log("props.product is NOT set!");
    }
  }, [props.product]);

  const updateHandler = () => {
    let productIsValid = true;
    console.log(product);

    if (product.id === 0) {
      alert("No product has been selected");
    } else {
      if (product.price === "") {
        alert("The price is not set correctly");
        productIsValid = false;
      } else if (product.price < 0 || 100000 < product.price) {
        productIsValid = false;
        alert("The price is not set correctly");
      }
      if (product.description === "") {
        if (product.description.length > 2500) {
          productIsValid = false;
          alert("The description is too long");
        }
      }
      if (product.name === "") {
        alert("The name is missing");
        productIsValid = false;
      } else if (100 < product.name.length) {
        productIsValid = false;
        alert("The name is too long");
      }

      if (productIsValid) {
        props.onUpdate(product);
      }
    }
  };

  const deleteHandler = () => {
    if (product.id === 0) {
      alert("No product has been selected");
    } else {
      var result = window.confirm("Are you sure you want to delete?");
      if (result === true) {
        props.onDelete(product.id);
        setProduct(emptyProduct);
      }
    }
  };

  return (
    <React.Fragment>
      <ProductForm
        product={product}
        productTypes={props.productTypes}
        setProduct={setProduct}
      />
      <div>
        <Button onClick={updateHandler} color="info">
          Update
        </Button>{" "}
        <Button onClick={deleteHandler} color="danger">
          Delete
        </Button>{" "}
      </div>
    </React.Fragment>
  );
};

export default EditProduct;
