import { useEffect, useState } from 'react';
import { fetchAllItems } from '../../../managers/ItemsManager.js';
import { Col, Container, Input, Label, Row, Spinner } from 'reactstrap';
import { AllItemCard } from './AllItemCard.js';
import { PaginationTool } from '../../utilities/PaginationTool.js';
import { SortFilterCategoryShell } from './sort-filter-categories/SortFilterCategoryShell.js';

export const AllItems = () => {
  const [allItems, setAllItems] = useState();
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(12);

  const getAllItems = () => {
    fetchAllItems().then(setAllItems);
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
    return <Spinner />;
  }

  return (
    <>
      <Container className="d-flex flex-column justify-content-between h-100">
        <Row>
          <Col lg="3">
            <SortFilterCategoryShell
              setAllItems={setAllItems}
              allItems={allItems}
              getAllItems={getAllItems}
              setItemsPerPage={setItemsPerPage}
            />
          </Col>
          <Col
            md="4"
            lg="9"
          >
            <div className="allItems-card-container d-flex  flex-wrap justify-content-around gap-1">
              {currentItems.map((i, index) => (
                <AllItemCard key={index}
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
