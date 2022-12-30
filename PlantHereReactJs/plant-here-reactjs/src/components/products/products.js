//React 
import React, { useState, useEffect } from "react";

//Meterial
import ProductCard from "./productCard";
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import Pagination from '@mui/material/Pagination';

// Request 
import request, { requestAllowAnonymous } from "../../services/requestService";
import { METHOD_TYPE } from "../../models/enum/methodType";
import { API_TYPE } from "../../models/enum/apiType";

//Provider
import { useAPI } from '../../providers/ApiProvider'


const Products = () => {
    const [page, setPage] = React.useState(1);
    const [productsCount, setProductsCount] = useState(24)
    const [products, setProducts] = useState([])

    //Provider
    const { isSelectedDotnetApi } = useAPI();

    // Page Size 
    const pageSize = 12;

    useEffect(() => {
        const fetchProductsCount = async () => {
            const response = await request('/Product/GetProductsCount', null, METHOD_TYPE.GET, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
            return response.data.data
        }

        const fetchDataProducts = async () => {
            const response = await requestAllowAnonymous(`/Product/GetProductsByPage/${page}/${pageSize}`, null, METHOD_TYPE.GET, API_TYPE.PLANT_HERE_DOTNET,isSelectedDotnetApi)
            return response.data.data
        }

        fetchDataProducts().then(data => {
            setProducts(data)
        }).catch(console.error)

        fetchProductsCount().then(x => setProductsCount(x.count)).catch(console.error)
        window.scrollTo(0, 0)
    }, [page]);

    const handleChange = (event, value) => {
        window.page= value
        setPage(value);
    };

    return (<React.Fragment>
        <Container fixed sx={{ mt: 8 }}  >
            <Grid container sx={{ p: 1 }} item direction="row"
                justifyContent="center"
                alignItems="center" >
                {products.map((product, index) => (
                    <ProductCard name={product.name}
                        description={product.description}
                        image={product.images[0].url}
                        price={product.price}
                        discountedPrice={product.discountedPrice}
                        uniqueId={product.uniqueId}
                        key={index} />
                ))}
            </Grid>
            <Grid sx={{ p: 1 }} container item direction="row"
                justifyContent="center"
                alignItems="center">
                <Grid >
                    <Pagination count={Math.ceil(productsCount / pageSize)} page={page} onChange={handleChange} color="primary" size="large" showFirstButton showLastButton />
                </Grid>
            </Grid>
        </Container>
    </React.Fragment>)
}

export default Products