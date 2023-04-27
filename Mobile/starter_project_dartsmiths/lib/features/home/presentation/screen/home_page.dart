import 'package:dartsmiths/features/home/presentation/widgets/search_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import '../../../../core/utils/style.dart';
import '../widgets/filter_button.dart';
import '../widgets/article_card.dart';
import '../widgets/profile.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: Padding(
            padding: EdgeInsets.all(15),
            child: Container(
                height: 35,
                width: 35,
                child: SvgPicture.asset("images/menu_bar.svg"))),
        title: Center(
            child: Text("Welcome  Back!",
                style: myTextStyle.copyWith(
                    color: Colors.black,
                    fontSize: 25,
                    fontWeight: FontWeight.w800))),
        actions: [ProfilePic()],
      ),
      body: Container(
        height: double.infinity,
        child: Column(
          children: [
            Searchbar(),
            Padding(
                padding: EdgeInsets.only(top: 20, right: 25, left: 25),
                child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      FilterButton(
                        text: "All",
                        isActive: true,
                      ),
                      FilterButton(
                        text: "Sports",
                        isActive: false,
                      ),
                      FilterButton(
                        text: "Tech",
                        isActive: false,
                      ),
                      FilterButton(
                        text: "Politics",
                        isActive: false,
                      )
                    ])),
            Expanded(
              child: ListView(
                children: [
                  ArticleCard(),
                  ArticleCard(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
