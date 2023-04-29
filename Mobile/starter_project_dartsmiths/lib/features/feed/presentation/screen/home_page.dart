import 'package:dartsmiths/core/utils/colors.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';
import 'package:dartsmiths/features/feed/presentation/widgets/search_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import '../../../../core/utils/style.dart';
import '../widgets/add_button.dart';
import '../widgets/filter_button.dart';
import '../widgets/article_card.dart';
import '../widgets/profile.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
      appBar: AppBar(
        elevation: 0,
        backgroundColor: whiteColor,
        leading: Padding(
            padding: EdgeInsets.all(15),
            child: Container(
                height: UIConverter.getComponentHeight(context, 35),
                width: UIConverter.getComponentWidth(context, 35),
                child: SvgPicture.asset("images/menu_bar.svg"))),
        title: Center(
            child: Text("Welcome  Back!",
                style: myTextStyle.copyWith(
                    color: blackColor,
                    fontSize: 25,
                    fontWeight: FontWeight.w800))),
        actions: [ProfilePic()],
      ),
      body: Container(
        height: double.infinity,
        child: Column(
          children: [
            Searchbar(),
          ]))
    );
  }
}
