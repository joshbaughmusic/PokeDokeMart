import { Container } from 'reactstrap';
import { ItemSearch } from './ItemSearch.js';
import { ItemSort } from './ItemSort.js';
import { ItemCategories } from './ItemCategories.js';

export const SortFilterCategoryShell = ({ setAllItems, allItems }) => {
  return (
    <>
      <div
        className="text-bg-dark"
        style={{
          marginTop: '15px',
        }}
      >
        {' '}
        <ItemSearch
          setAllItems={setAllItems}
          allItems={allItems}
        />
        <br />
        <ItemSort
          setAllItems={setAllItems}
          allItems={allItems}
        />
        <br />
        <ItemCategories
          setAllItems={setAllItems}
          allItems={allItems}
        />
      </div>
    </>
  );
};
