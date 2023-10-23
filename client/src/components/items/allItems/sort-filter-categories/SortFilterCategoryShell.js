import { Container } from 'reactstrap';
import { ItemSearch } from './ItemSearch.js';
import { ItemSort } from './ItemSort.js';
import { ItemCategories } from './ItemCategories.js';

export const SortFilterCategoryShell = ({ setAllItems, getAllItems, allItems }) => {
  return (
    <>
      <div
        className="text-bg-dark"
        style={{
          marginTop: '15px',
        }}
      >
        <ItemSearch
          setAllItems={setAllItems}
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
      </div>
    </>
  );
};
