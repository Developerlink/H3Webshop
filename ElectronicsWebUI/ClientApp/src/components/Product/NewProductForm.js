import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

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

const testProduct = {
    id: "0",
    name: "Test PC",
    description: "Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum har ikke alene overlevet fem århundreder, men har også vundet indpas i elektronisk typografi uden væsentlige ændringe",
    price: "5000",
    productType: {
      id: 1,
      name: "",
    },
  };

const NewProductForm = (props) => {
  const [product, setProduct] = useState(testProduct);
  const [selectedOption, setSelectedOption] = useState(1);

  const onChangeHandler = (event) => {
    const { name, value } = event.target;

    console.log(value);

    setProduct((prevValue) => {
      return {
        ...prevValue,
        [name]: value,
      };
    });

    //console.log(product);
  };

  const selectOptionHandler = (event) => {
    const { name: productType, value: id } = event.target;
    console.log(productType + " " + id);
    setProduct((prevValue) => {
      return {
        ...prevValue,
        [productType]: { id: id, name: ''},
      };
    });
    setSelectedOption(id);
    console.log(product);
  };

  const saveHandler = () => {
    props.onSubmit(product);
  };

  return (
    <React.Fragment>
        <h3>New Product</h3>
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
          <Input
            type="select"
            name="productType"
            value={selectedOption}
            onChange={selectOptionHandler}
          >
            {props.productTypes.map((productType) => (
              <option
                onClick={selectOptionHandler}
                key={productType.id}
                value={productType.id}
              >
                {productType.name}
              </option>
            ))}
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
      </Form>
      <Button onClick={saveHandler} color="success">
        Save
      </Button>
    </React.Fragment>
  );
};

export default NewProductForm;
