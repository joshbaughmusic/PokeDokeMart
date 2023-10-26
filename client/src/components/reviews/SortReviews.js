import { Input, Label } from 'reactstrap';

export const SortReviews = ({ allReviewsByItem, setAllReviewsByItem }) => {

    const handleSort = (e) => {
        const choice = e.target.value
        if (choice === 'newest') {
          setAllReviewsByItem(allReviewsByItem.sort((a, b) => b.date - a.date));
        } else if (choice === 'oldest') {
          setAllReviewsByItem(allReviewsByItem.sort((a, b) => a.date - b.date));
        } else if (choice === 'highest') {
          setAllReviewsByItem(allReviewsByItem.sort((a, b) => b.rating - a.rating));
        } else if (choice === 'lowest') {
          setAllReviewsByItem(allReviewsByItem.sort((a, b) => a.rating - b.rating));
        }
    }
  return (
    <>
      <div>
        <Label>Sort Reviews:</Label>
        <Input type="select" onChange={handleSort}>
          <option value="newest">Newest First</option>
          <option value="oldest">Oldest First</option>
          <option value="highest">{`Rating (High to Low)`}</option>
          <option value="lowest">{`Rating (Low to High)`}</option>
        </Input>
      </div>
    </>
  );
};
