import Link from "next/link"

export default function Footer() {
  return (
    <footer className="bg-[var(--eatwell-dark)] text-white py-16">
      <div className="container mx-auto px-4">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-8 mb-8">
          <div>
            <h2 className="text-lg font-serif mb-4">About Us</h2>
            <p className="text-gray-300 leading-relaxed">
              Lorem ipsum dolor sit amet, consectetur adipisicing elit. Cumque, similique, delectus blanditiis odit
              expedita amet.
            </p>
          </div>

          <div>
            <h2 className="text-sm font-bold uppercase tracking-wider text-gray-400 mb-4">The Restaurant</h2>
            <ul className="space-y-2">
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  About Us
                </Link>
              </li>
              <li>
                <Link href="/chefs" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Chefs
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Events
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Contact
                </Link>
              </li>
            </ul>
          </div>

          <div>
            <h2 className="text-sm font-bold uppercase tracking-wider text-gray-400 mb-4">Useful Links</h2>
            <ul className="space-y-2">
              <li>
                <Link href="/menu" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Foods
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Drinks
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Breakfast
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Brunch
                </Link>
              </li>
              <li>
                <Link href="#" className="text-gray-300 hover:text-[var(--eatwell-orange)] transition-colors">
                  Dinner
                </Link>
              </li>
            </ul>
          </div>

          <div>
            <h2 className="text-sm font-bold uppercase tracking-wider text-gray-400 mb-4">Follow Us</h2>
            <div className="flex space-x-4">
              <a
                href="#"
                className="w-12 h-12 bg-white/5 rounded-full flex items-center justify-center hover:text-[var(--eatwell-orange)] transition-colors"
              >
                <span className="text-xl">📘</span>
              </a>
              <a
                href="#"
                className="w-12 h-12 bg-white/5 rounded-full flex items-center justify-center hover:text-[var(--eatwell-orange)] transition-colors"
              >
                <span className="text-xl">🐦</span>
              </a>
              <a
                href="#"
                className="w-12 h-12 bg-white/5 rounded-full flex items-center justify-center hover:text-[var(--eatwell-orange)] transition-colors"
              >
                <span className="text-xl">📷</span>
              </a>
            </div>
          </div>
        </div>

        <div className="text-center pt-8 border-t border-gray-600">
          <p className="text-gray-400">
            &copy; {new Date().getFullYear()} All rights reserved | Made with ❤️ by EatWell Restaurant
          </p>
        </div>
      </div>
    </footer>
  )
}
