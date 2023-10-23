import { useEffect, useState } from 'react';
import { fetchAllItems } from '../../../managers/ItemsManager.js';
import { Col, Container, Row, Spinner } from 'reactstrap';
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
      <Container>
        <Row>
          <Col lg="3">
            <SortFilterCategoryShell setAllItems={setAllItems} allItems={allItems} />
          </Col>
          <Col
            md="4"
            lg="9"
          >
            <div className="allItems-card-container d-flex  flex-wrap justify-content-around">
              {currentItems.map((i, index) => (
                <AllItemCard
                  item={i}
                  index={index}
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
