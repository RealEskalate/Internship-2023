import React from 'react';

export type SearchBarProp = {
    value: string
    onChange: (value: string) => void
}

const SearchBar: React.FC<SearchBarProp> = ({ value, onChange }: SearchBarProp) => {
    return (
        <div className="mb-3">
            <div className="relative mb-4 flex w-full flex-wrap items-stretch">
                <input
                    type="search"
                    onChange={(e) => onChange(e.target.value)}
                    className="h-16 relative m-0 -mr-0.5 block w-[1px] min-w-0 flex-auto rounded-3xl border border-solid border-gray-300 bg-transparent bg-clip-padding px-3 py-[0.25rem] text-base font-normal leading-[1.6] text-gray-700 outline-none transition duration-200 ease-in-out focus:z-[3] focus:border-primary focus:text-gray-700 focus:shadow-[inset_0_0_0_1px_rgb(59,113,202)] focus:outline-none dark:text-gray-200 dark:placeholder:text-gray-200"
                    placeholder="Search"
                    aria-label="Search"
                    aria-describedby="button-addon1" />
            </div>
        </div>
    );
};

export default SearchBar;