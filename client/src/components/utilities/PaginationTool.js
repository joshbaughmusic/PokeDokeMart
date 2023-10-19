import { Pagination, PaginationItem, PaginationLink } from "reactstrap";

export const PaginationTool = ({
  itemsPerPage,
  totalItems,
  paginate,
  paginatePrevOrNext,
  currentPage
}) => {
  const pageNumbers = [];

  for (let i = 1; i <= Math.ceil(totalItems / itemsPerPage); i++) {
    pageNumbers.push(i);
  }

  return (
    <div>
      <Pagination>
        <PaginationItem>
          <PaginationLink
            first
            className="rounded-0"
            onClick={() => paginate(1)}
          />
        </PaginationItem>
        <PaginationItem>
          <PaginationLink
            onClick={() => (currentPage > 1 ? paginatePrevOrNext('prev') : '')}
            previous
          />
        </PaginationItem>
        {pageNumbers.map((p, index) =>
          p === currentPage ? (
            <PaginationItem
              active
              key={index}
            >
              <PaginationLink onClick={() => paginate(p)}>{p}</PaginationLink>
            </PaginationItem>
          ) : (
            <PaginationItem key={index}>
              <PaginationLink onClick={() => paginate(p)}>{p}</PaginationLink>
            </PaginationItem>
          )
        )}
        <PaginationItem>
          <PaginationLink
            onClick={() =>
              currentPage < pageNumbers.length ? paginatePrevOrNext('next') : ''
            }
            next
          />
        </PaginationItem>
        <PaginationItem>
          <PaginationLink
            className="rounded-0"
            onClick={() => paginate(pageNumbers.length)}
            last
          />
        </PaginationItem>
      </Pagination>
    </div>
  );
};
