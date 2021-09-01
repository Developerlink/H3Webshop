import React, { useEffect, useState } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

const ProductForm = (props) => {
  const [product, setProduct] = useState({
    id: "",
    name: "",
    description: "",
    price: "",
    productType: {
      id: "",
      name: "",
    },
  });

  useEffect(() => {
    if(props.product)
    {
      console.log("props.product is set")
      console.log(props.product.id);
      setProduct(props.product);
    } else {
      console.log("props.product is NOT set!")
    }
  },[props.product])

  const onChangeHandler = (event) => {
    const { name, value } = event.target;

    console.log(value);

    setProduct((prevValue) => {
      return {
        ...prevValue,
        [name]: value,
      };
    });

    console.log(product);
  };

  const saveHandler = () => {
    alert("Saving product");
  };

  const updateHandler = () => {
    alert("Updating product");
  };

  const deleteHandler = () => {
    alert("Deleting product");
  };

  return (
    <React.Fragment>
      <Form>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            name="name"
            id="name"
            placeholder="product name"
            value={product.name}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Select Product Type</Label>
          <Input type="select" name="select" id="exampleSelect">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Decription</Label>
          <Input
            type="textarea"
            name="description"
            id="description"
            value={product.description}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Input
            type="number"
            name="price"
            id="price"
            placeholder="amount"
            step="1"
            min={0}
            max={100000}
            value={product.price}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Input type="hidden" name="id" value={product.id} />
        </FormGroup>

        <div>
          <Button onClick={saveHandler} color="success">
            Save
          </Button>{" "}
          <Button onClick={updateHandler} color="info">
            Update
          </Button>{" "}
          <Button onClick={deleteHandler} color="danger">
            Delete
          </Button>{" "}
        </div>
      </Form>
    </React.Fragment>
  );
};

export default ProductForm;
