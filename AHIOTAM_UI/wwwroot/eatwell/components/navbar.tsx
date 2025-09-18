"use client"

import Link from "next/link"
import { useState, useEffect } from "react"

export default function Navbar() {
  const [isScrolled, setIsScrolled] = useState(false)
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false)

  useEffect(() => {
    const handleScroll = () => {
      setIsScrolled(window.scrollY > 50)
    }
    window.addEventListener("scroll", handleScroll)
    return () => window.removeEventListener("scroll", handleScroll)
  }, [])

  return (
    <nav
      className={`fixed top-0 left-0 right-0 z-50 transition-all duration-300 ${
        isScrolled ? "bg-white shadow-lg" : "bg-transparent"
      }`}
    >
      <div className="container mx-auto px-4">
        <div className="flex items-center justify-between h-20">
          <Link
            href="/"
            className={`text-xl font-bold uppercase tracking-wider ${isScrolled ? "text-black" : "text-white"}`}
          >
            EatWell
          </Link>

          <div className="hidden md:flex items-center space-x-8">
            <Link
              href="/"
              className={`text-sm uppercase tracking-wider transition-colors ${
                isScrolled
                  ? "text-black hover:text-[var(--eatwell-orange)]"
                  : "text-white hover:text-[var(--eatwell-orange)]"
              }`}
            >
              Home
            </Link>
            <Link
              href="/menu"
              className={`text-sm uppercase tracking-wider transition-colors ${
                isScrolled
                  ? "text-black hover:text-[var(--eatwell-orange)]"
                  : "text-white hover:text-[var(--eatwell-orange)]"
              }`}
            >
              Menu
            </Link>
            <Link
              href="/chefs"
              className={`text-sm uppercase tracking-wider transition-colors ${
                isScrolled
                  ? "text-black hover:text-[var(--eatwell-orange)]"
                  : "text-white hover:text-[var(--eatwell-orange)]"
              }`}
            >
              Chefs
            </Link>
            <Link
              href="#contact"
              className={`text-sm uppercase tracking-wider transition-colors ${
                isScrolled
                  ? "text-black hover:text-[var(--eatwell-orange)]"
                  : "text-white hover:text-[var(--eatwell-orange)]"
              }`}
            >
              Contact
            </Link>
          </div>

          <button
            className={`md:hidden ${isScrolled ? "text-black" : "text-white"}`}
            onClick={() => setIsMobileMenuOpen(!isMobileMenuOpen)}
          >
            <span className="text-sm uppercase tracking-wider">Menu</span>
          </button>
        </div>

        {isMobileMenuOpen && (
          <div className="md:hidden bg-black">
            <div className="px-2 pt-2 pb-3 space-y-1">
              <Link href="/" className="block px-3 py-2 text-white hover:text-[var(--eatwell-orange)]">
                Home
              </Link>
              <Link href="/menu" className="block px-3 py-2 text-white hover:text-[var(--eatwell-orange)]">
                Menu
              </Link>
              <Link href="/chefs" className="block px-3 py-2 text-white hover:text-[var(--eatwell-orange)]">
                Chefs
              </Link>
              <Link href="#contact" className="block px-3 py-2 text-white hover:text-[var(--eatwell-orange)]">
                Contact
              </Link>
            </div>
          </div>
        )}
      </div>
    </nav>
  )
}
