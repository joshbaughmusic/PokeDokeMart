import { Input, Label } from 'reactstrap';

export const SortReviews = ({ allReviewsByItem, setAllReviewsByItem }) => {

const handleSort = (e) => {
  const choice = e.target.value;
  let sortedReviews = [...allReviewsByItem];

  if (choice === 'newest') {
    sortedReviews.sort((a, b) => new Date(b.date) - new Date(a.date));
  } else if (choice === 'oldest') {
    sortedReviews.sort((a, b) => new Date(a.date) - new Date(b.date));
  } else if (choice === 'highest') {
    sortedReviews.sort((a, b) => b.rating - a.rating);
  } else if (choice === 'lowest') {
    sortedReviews.sort((a, b) => a.rating - b.rating);
  }

  setAllReviewsByItem(sortedReviews);
};



  return (
    <>
      <div>
        <Label>Sort Reviews:</Label>
        <Input className='rounded-0' type="select" onChange={handleSort}>
          <option value="newest">Newest First</option>
          <option value="oldest">Oldest First</option>
          <option value="highest">{`Rating (High to Low)`}</option>
          <option value="lowest">{`Rating (Low to High)`}</option>
        </Input>
      </div>
    </>
  );
};
