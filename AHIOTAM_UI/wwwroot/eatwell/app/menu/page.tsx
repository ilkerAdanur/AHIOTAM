"use client"

import { useState } from "react"
import Navbar from "@/components/navbar"
import Footer from "@/components/footer"

const menuItems = {
  breakfast: [
    {
      id: 1,
      name: "Salted Fried Chicken",
      description:
        "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.",
      price: "$35.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
    {
      id: 2,
      name: "Italian Sauce Mushroom",
      description:
        "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.",
      price: "$24.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 3,
      name: "Fried Potato w/ Garlic",
      description:
        "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.",
      price: "$14.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
    {
      id: 4,
      name: "Fresh Morning Eggs",
      description: "Perfectly cooked eggs with seasonal vegetables and herbs, served with artisan bread.",
      price: "$18.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 5,
      name: "Avocado Toast Special",
      description: "Smashed avocado on sourdough with cherry tomatoes, feta cheese, and balsamic glaze.",
      price: "$16.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
    {
      id: 6,
      name: "Pancake Stack",
      description: "Fluffy pancakes served with maple syrup, fresh berries, and whipped cream.",
      price: "$12.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
  ],
  lunch: [
    {
      id: 7,
      name: "Grilled Salmon Fillet",
      description: "Fresh Atlantic salmon grilled to perfection with lemon herbs and seasonal vegetables.",
      price: "$28.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
    {
      id: 8,
      name: "Caesar Salad Supreme",
      description: "Crisp romaine lettuce with parmesan cheese, croutons, and our signature Caesar dressing.",
      price: "$19.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
    {
      id: 9,
      name: "Beef Burger Deluxe",
      description: "Juicy beef patty with lettuce, tomato, cheese, and our special sauce on a brioche bun.",
      price: "$22.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 10,
      name: "Pasta Primavera",
      description: "Fresh pasta with seasonal vegetables in a light cream sauce, topped with parmesan.",
      price: "$21.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
    {
      id: 11,
      name: "Chicken Wrap",
      description: "Grilled chicken with fresh vegetables and tzatziki sauce wrapped in a soft tortilla.",
      price: "$17.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 12,
      name: "Quinoa Power Bowl",
      description: "Nutritious quinoa with roasted vegetables, chickpeas, and tahini dressing.",
      price: "$20.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
  ],
  dinner: [
    {
      id: 13,
      name: "Ribeye Steak Premium",
      description: "Premium cut ribeye steak cooked to your preference with garlic mashed potatoes.",
      price: "$45.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 14,
      name: "Lobster Thermidor",
      description: "Fresh lobster in a rich cream sauce with herbs, baked to golden perfection.",
      price: "$52.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
    {
      id: 15,
      name: "Duck Confit",
      description: "Slow-cooked duck leg with orange glaze, served with roasted root vegetables.",
      price: "$38.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
    {
      id: 16,
      name: "Seafood Risotto",
      description: "Creamy arborio rice with mixed seafood, white wine, and fresh herbs.",
      price: "$32.50",
      image: "/eatwell-master/images/menu_3.jpg",
    },
    {
      id: 17,
      name: "Lamb Rack",
      description: "Herb-crusted rack of lamb with rosemary jus and seasonal vegetables.",
      price: "$42.50",
      image: "/eatwell-master/images/menu_2.jpg",
    },
    {
      id: 18,
      name: "Vegetarian Tasting",
      description: "A selection of our finest vegetarian dishes showcasing seasonal produce.",
      price: "$29.50",
      image: "/eatwell-master/images/menu_1.jpg",
    },
  ],
}

export default function MenuPage() {
  const [activeTab, setActiveTab] = useState<"breakfast" | "lunch" | "dinner">("breakfast")

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
          <h1 className="text-5xl md:text-6xl font-serif mb-4">Delicious Menu</h1>
          <p className="text-xl text-white/80 max-w-2xl mx-auto px-4">
            Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the
            blind texts.
          </p>
        </div>
      </section>

      {/* Menu Section */}
      <section className="py-20">
        <div className="container mx-auto px-4">
          {/* Tab Navigation */}
          <div className="flex justify-center mb-12">
            <div className="flex space-x-2 bg-gray-100 p-1 rounded-lg">
              {(["breakfast", "lunch", "dinner"] as const).map((tab) => (
                <button
                  key={tab}
                  onClick={() => setActiveTab(tab)}
                  className={`px-8 py-3 text-sm uppercase tracking-wider font-medium transition-all duration-300 ${
                    activeTab === tab
                      ? "bg-black text-white border-2 border-black"
                      : "text-gray-500 border-2 border-gray-300 hover:border-gray-400"
                  }`}
                >
                  {tab}
                </button>
              ))}
            </div>
          </div>

          {/* Menu Items */}
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-8 max-w-6xl mx-auto">
            {menuItems[activeTab].map((item) => (
              <div
                key={item.id}
                className="flex gap-4 p-6 bg-white rounded-lg shadow-sm hover:shadow-md transition-shadow duration-300"
              >
                <img
                  src={item.image || "/placeholder.svg"}
                  alt={item.name}
                  className="w-24 h-24 rounded-full object-cover flex-shrink-0"
                />
                <div className="flex-1">
                  <h5 className="text-xl font-serif font-bold mb-2">{item.name}</h5>
                  <p className="text-gray-600 mb-3 leading-relaxed">{item.description}</p>
                  <h6 className="text-2xl font-serif font-bold text-[var(--eatwell-orange)]">{item.price}</h6>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      <Footer />
    </div>
  )
}
