import { useEffect, useState } from 'react';
import { fetchAllItems } from '../../../managers/ItemsManager.js';
import { Col, Container, Input, Label, Row, Spinner } from 'reactstrap';
import { AllItemCard } from './AllItemCard.js';
import { PaginationTool } from '../../utilities/PaginationTool.js';
import { SortFilterCategoryShell } from './sort-filter-categories/SortFilterCategoryShell.js';
import './AllItems.css';
import PokeballLoading from '../../../images/pokeball-loading.gif';

export const AllItems = () => {
  const [allItems, setAllItems] = useState();
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(12);

  const getAllItems = () => {
    fetchAllItems().then((res) => {
      setTimeout(() => {
        setAllItems(res);
      }, 300);
    });
  };

  useEffect(() => {
    getAllItems();
  }, []);

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = allItems?.slice(indexOfFirstItem, indexOfLastItem);

  const paginate = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const paginatePrevOrNext = (value) => {
    if (value === 'prev') {
      setCurrentPage(currentPage - 1);
    } else {
      setCurrentPage(currentPage + 1);
    }
  };

  if (!allItems) {
    return (
      <>
        <div className="d-flex justify-content-center h-75 align-items-center">
          <img
            style={{
              width: '200px',
            }}
            src={PokeballLoading}
            alt=""
          />
        </div>
      </>
    );
  }

  return (
    <>
      <Container className="d-flex flex-column all-items-container-outer justify-content-between">
        <Row className="all-items-container-inner">
          <Col lg="3">
            <SortFilterCategoryShell
              setAllItems={setAllItems}
              allItems={allItems}
              getAllItems={getAllItems}
              setItemsPerPage={setItemsPerPage}
              setCurrentPage={setCurrentPage}
            />
          </Col>
          <Col
            md="4"
            lg="9"
          >
            <div className="allItems-card-container d-flex  flex-wrap gap-4">
              {currentItems.map((i, index) => (
                <AllItemCard
                  key={index}
                  item={i}
                />
              ))}
            </div>
          </Col>
        </Row>

        <div className="d-flex justify-content-center mt-5">
          <PaginationTool
            itemsPerPage={itemsPerPage}
            totalItems={allItems.length}
            paginate={paginate}
            paginatePrevOrNext={paginatePrevOrNext}
            currentPage={currentPage}
          />
        </div>
      </Container>
    </>
  );
};
