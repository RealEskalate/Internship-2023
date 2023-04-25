import 'package:flutter/material.dart';
import '../widgets/articlecard_widget.dart';
import '../widgets/filters_widget.dart';
import '../widgets/profilepic_widget.dart';
import '../widgets/searchbar_widget.dart';

class HomePage extends StatelessWidget {
  const HomePage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    final screenHeight = MediaQuery.of(context).size.height;
    return Scaffold(
      backgroundColor: const Color(0xFFF8FAFF),
      body: SafeArea(
          child: Column(
        crossAxisAlignment: CrossAxisAlignment.end,
        children: [
          Padding(
            padding: EdgeInsets.fromLTRB(screenWidth * 0.03,
                screenHeight * 0.03, screenWidth * 0.03, screenHeight * 0.01),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                IconButton(
                    onPressed: () {},
                    icon: const Icon(
                      Icons.menu,
                    )),
                Text(
                  "Welcome Back!",
                  style: TextStyle(
                      fontSize: screenWidth * 0.07,
                      fontFamily: "Poppins",
                      fontWeight: FontWeight.w700),
                ),
                const Profilepic()
              ],
            ),
          ),
          const SearchBar(),
          Padding(
            padding: EdgeInsets.all(screenWidth * 0.02),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Filters(
                  lable: "All",
                  active: true,
                ),
                Filters(
                  lable: "Sports",
                ),
                Filters(
                  lable: "Tech",
                ),
                Filters(
                  lable: "Politics",
                ),
              ],
            ),
          ),
          Expanded(
            child: ListView(
              children: const [
                Padding(
                  padding: EdgeInsets.all(20),
                  child: ArticleCard(),
                ),
                Padding(
                  padding: EdgeInsets.all(20),
                  child: ArticleCard(),
                ),
              ],
            ),
          ),

          Padding(
            padding: const EdgeInsets.fromLTRB(0, 0, 20, 20),
            child: SizedBox(
              height: 50,
              child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(12),
                    ),
                  ),
                  onPressed: () {},
                  child: const Icon(Icons.add)),
            ),
          )

          // const ArticleCard()
        ],
      )),
    );
  }
}
