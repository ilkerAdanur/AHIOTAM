import Navbar from "@/components/navbar"
import Footer from "@/components/footer"

const chefs = [
  {
    id: 1,
    name: "Marco Rodriguez",
    title: "Executive Chef",
    description:
      "With over 15 years of culinary experience, Marco brings passion and creativity to every dish. Specializing in Mediterranean and modern fusion cuisine.",
    image: "/eatwell-master/images/about_img_1.jpg",
    specialties: ["Mediterranean", "Fusion", "Seafood"],
  },
  {
    id: 2,
    name: "Sarah Chen",
    title: "Pastry Chef",
    description:
      "Sarah's artistic approach to pastry and desserts has earned recognition worldwide. She creates beautiful and delicious sweet masterpieces.",
    image: "/eatwell-master/images/menu_1.jpg",
    specialties: ["Pastry", "Desserts", "French Cuisine"],
  },
  {
    id: 3,
    name: "Antonio Rossi",
    title: "Sous Chef",
    description:
      "Antonio's expertise in Italian cuisine and his attention to detail make him an invaluable part of our culinary team.",
    image: "/eatwell-master/images/menu_2.jpg",
    specialties: ["Italian", "Pasta", "Wine Pairing"],
  },
  {
    id: 4,
    name: "Emily Johnson",
    title: "Head Baker",
    description:
      "Emily starts her day at 4 AM to ensure our guests enjoy the freshest bread and baked goods. Her dedication is unmatched.",
    image: "/eatwell-master/images/menu_3.jpg",
    specialties: ["Artisan Bread", "Breakfast", "Organic Baking"],
  },
  {
    id: 5,
    name: "David Kim",
    title: "Grill Master",
    description:
      "David's mastery of the grill and his knowledge of meat preparation ensure every steak and grilled dish is cooked to perfection.",
    image: "/eatwell-master/images/offer_1.jpg",
    specialties: ["Grilling", "BBQ", "Meat Preparation"],
  },
  {
    id: 6,
    name: "Isabella Martinez",
    title: "Vegetarian Specialist",
    description:
      "Isabella creates innovative vegetarian and vegan dishes that surprise and delight even the most dedicated meat lovers.",
    image: "/eatwell-master/images/offer_2.jpg",
    specialties: ["Vegetarian", "Vegan", "Healthy Cuisine"],
  },
]

export default function ChefsPage() {
  return (
    <div className="min-h-screen">
      <Navbar />

      {/* Hero Section */}
      <section
        className="h-96 flex items-center justify-center text-center text-white relative"
        style={{
          backgroundImage: `url('/eatwell-master/images/bg_3.jpg')`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
        }}
      >
        <div className="absolute inset-0 bg-black/60"></div>
        <div className="relative z-10">
          <h1 className="text-5xl md:text-6xl font-serif mb-4">Meet Our Chefs</h1>
          <p className="text-xl text-white/80 max-w-2xl mx-auto px-4">
            The talented culinary artists behind our exceptional dishes and unforgettable dining experiences.
          </p>
        </div>
      </section>

      {/* Chefs Section */}
      <section className="py-20">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h4 className="text-sm uppercase tracking-widest text-gray-400 mb-4">Our Team</h4>
            <h2 className="text-4xl md:text-5xl font-serif mb-6">Culinary Excellence</h2>
            <p className="text-gray-600 max-w-3xl mx-auto leading-relaxed">
              Our team of passionate chefs brings together diverse culinary backgrounds and expertise to create
              memorable dining experiences. Each chef contributes their unique skills and creativity to our kitchen.
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            {chefs.map((chef) => (
              <div
                key={chef.id}
                className="bg-white rounded-lg shadow-lg overflow-hidden hover:shadow-xl transition-shadow duration-300"
              >
                <div className="aspect-square overflow-hidden">
                  <img
                    src={chef.image || "/placeholder.svg"}
                    alt={chef.name}
                    className="w-full h-full object-cover hover:scale-105 transition-transform duration-300"
                  />
                </div>
                <div className="p-6">
                  <h3 className="text-2xl font-serif font-bold mb-2">{chef.name}</h3>
                  <h4 className="text-[var(--eatwell-orange)] font-medium mb-4">{chef.title}</h4>
                  <p className="text-gray-600 mb-4 leading-relaxed">{chef.description}</p>

                  <div className="mb-4">
                    <h5 className="font-semibold mb-2 text-sm uppercase tracking-wider">Specialties:</h5>
                    <div className="flex flex-wrap gap-2">
                      {chef.specialties.map((specialty, index) => (
                        <span
                          key={index}
                          className="px-3 py-1 bg-[var(--eatwell-light)] text-gray-700 text-sm rounded-full"
                        >
                          {specialty}
                        </span>
                      ))}
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* Call to Action */}
      <section className="py-20 bg-[var(--eatwell-light)]">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-4xl font-serif mb-6">Experience Our Culinary Art</h2>
          <p className="text-gray-600 mb-8 max-w-2xl mx-auto leading-relaxed">
            Book a table today and let our talented chefs create an unforgettable dining experience for you and your
            loved ones.
          </p>
          <button className="bg-[var(--eatwell-orange)] text-white px-10 py-4 text-lg font-serif hover:bg-[var(--eatwell-orange-dark)] transition-colors duration-300">
            Make a Reservation
          </button>
        </div>
      </section>

      <Footer />
    </div>
  )
}
