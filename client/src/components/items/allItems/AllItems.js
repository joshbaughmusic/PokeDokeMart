import { useEffect, useState } from 'react';
import { fetchAllItems } from '../../../managers/ItemsManager.js';
import { Spinner } from 'reactstrap';
import { AllItemCard } from './AllItemCard.js';
import { PaginationTool } from '../../utilities/PaginationTool.js';

export const AllItems = () => {
  const [allItems, setAllItems] = useState();
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(15);

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
      <div className="container">
        <div className="container allItems-card-container d-flex  flex-wrap justify-content-around">
          {currentItems.map((i, index) => (
            <AllItemCard
              item={i}
              index={index}
            />
          ))}
        </div>
        <div className='d-flex justify-content-center mt-5'>
          <PaginationTool
            itemsPerPage={itemsPerPage}
            totalItems={allItems.length}
            paginate={paginate}
            paginatePrevOrNext={paginatePrevOrNext}
            currentPage={currentPage}
          />
        </div>
      </div>
    </>
  );
};
