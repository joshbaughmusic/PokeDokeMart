import { Button, Container } from 'reactstrap';
import { ItemSearch } from './ItemSearch.js';
import { ItemSort } from './ItemSort.js';
import { ItemCategories } from './ItemCategories.js';

export const SortFilterCategoryShell = ({ setAllItems, getAllItems, allItems }) => {

  const handleReset = () => {
    getAllItems();
  };
  
  return (
    <>
      <div
        style={{
          marginTop: '15px',
        }}
      >
        <ItemSearch
          setAllItems={setAllItems}
          allItems={allItems}
        />
        <ItemSort
          setAllItems={setAllItems}
          allItems={allItems}
          getAllItems={getAllItems}
        />
        <ItemCategories
          setAllItems={setAllItems}
          getAllItems={getAllItems}
        />
        <Button onClick={handleReset}>Reset</Button>
      </div>
    </>
  );
};
