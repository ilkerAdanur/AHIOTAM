import Navbar from "@/components/navbar"
import Footer from "@/components/footer"
import Link from "next/link"

export default function HomePage() {
  return (
    <div className="min-h-screen">
      <Navbar />

      {/* Hero Section */}
      <section
        className="min-h-screen flex items-center justify-center text-center text-white relative"
        style={{
          backgroundImage: `url('/eatwell-master/images/bg_3.jpg')`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
        }}
      >
        <div className="absolute inset-0 bg-black/60"></div>
        <div className="relative z-10 max-w-4xl mx-auto px-4">
          <h1 className="text-5xl md:text-7xl font-serif mb-6">Welcome To EatWell</h1>
          <h2 className="text-xl md:text-2xl font-light mb-8 text-white/80">
            Come and eat well with our delicious & healthy foods.
          </h2>
          <Link
            href="#reservation"
            className="inline-block bg-transparent border-2 border-white/80 text-white px-10 py-4 text-lg font-serif hover:bg-white hover:text-black transition-all duration-300"
          >
            Reservation
          </Link>
        </div>
      </section>

      {/* About Section */}
      <section className="py-20">
        <div className="container mx-auto px-4">
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-12 items-center">
            <div>
              <h4 className="text-sm uppercase tracking-widest text-gray-400 mb-4">Our Story</h4>
              <h2 className="text-4xl md:text-5xl font-serif mb-6">Welcome</h2>
              <p className="text-gray-600 mb-6 leading-relaxed">
                Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the
                blind texts.
              </p>
              <p className="text-gray-600 mb-8 leading-relaxed">
                A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a
                paradisematic country, in which roasted parts of sentences fly into your mouth.
              </p>
              <Link
                href="#about"
                className="inline-block bg-gray-200 text-gray-700 px-8 py-3 font-serif hover:bg-[var(--eatwell-orange)] hover:text-white transition-all duration-300"
              >
                Learn More About Us
              </Link>
            </div>
            <div>
              <img
                src="/eatwell-master/images/about_img_1.jpg"
                alt="About EatWell Restaurant"
                className="w-full h-auto rounded-lg shadow-lg"
              />
            </div>
          </div>
        </div>
      </section>

      {/* Quick Links Section */}
      <section className="py-20 bg-[var(--eatwell-light)]">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-4xl font-serif mb-12">Explore Our Restaurant</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-8 max-w-4xl mx-auto">
            <Link
              href="/menu"
              className="group bg-white p-8 rounded-lg shadow-lg hover:shadow-xl transition-all duration-300"
            >
              <div className="mb-4">
                <img
                  src="/eatwell-master/images/menu_1.jpg"
                  alt="Our Menu"
                  className="w-24 h-24 rounded-full mx-auto object-cover"
                />
              </div>
              <h3 className="text-2xl font-serif mb-4 group-hover:text-[var(--eatwell-orange)] transition-colors">
                Our Menu
              </h3>
              <p className="text-gray-600">
                Discover our delicious breakfast, lunch, and dinner options crafted with the finest ingredients.
              </p>
            </Link>

            <Link
              href="/chefs"
              className="group bg-white p-8 rounded-lg shadow-lg hover:shadow-xl transition-all duration-300"
            >
              <div className="mb-4">
                <img
                  src="/eatwell-master/images/about_img_1.jpg"
                  alt="Our Chefs"
                  className="w-24 h-24 rounded-full mx-auto object-cover"
                />
              </div>
              <h3 className="text-2xl font-serif mb-4 group-hover:text-[var(--eatwell-orange)] transition-colors">
                Meet Our Chefs
              </h3>
              <p className="text-gray-600">
                Get to know the talented culinary artists behind our exceptional dishes and flavors.
              </p>
            </Link>
          </div>
        </div>
      </section>

      <Footer />
    </div>
  )
}
