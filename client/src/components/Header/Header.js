import React from 'react';
import { Dropdown } from "flowbite-react"
import Logo from './Logo';
import NavMenu from './NavMenu';
import UserMenu from './UserMenu';

var user = {
  name: "Jane Doe",
  email: "",
  profile_picture: "https://i.pravatar.cc/200"
}

function Header() {
  return (
    <nav className="bg-white border-gray-200 dark:bg-gray-900">
      <div className="max-w-screen-3xl flex flex-wrap items-center justify-between mx-auto p-4">
        <Logo />
        <UserMenu user={user} />
        <NavMenu />
      </div>
    </nav>
  );
}

export default Header;
