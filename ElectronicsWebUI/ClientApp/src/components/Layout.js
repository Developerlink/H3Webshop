import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Route } from 'react-router';
import Home from './Home';
import ProductForm from './ProductForm';
import ProductList from './ProductList';


class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <NavMenu />
                <Container>
                    <Route exact path='/' component={Home} />
                    <Route path='/products' component={ProductList} />
                    <Route path='/product' component={ProductForm} />
                </Container>
            </div>
        );
    }
}

export { Layout };
