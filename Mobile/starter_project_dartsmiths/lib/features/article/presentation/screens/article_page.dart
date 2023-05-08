// ignore_for_file: camel_case_types

import 'package:dartsmiths/core/utils/images.dart';
import 'package:dartsmiths/features/article/presentation/widgets/article_profile.dart';
import 'package:dartsmiths/features/article/presentation/widgets/like_button.dart';
import 'package:flutter/material.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';
import 'package:dartsmiths/core/utils/colors.dart';

class ArticleReading extends StatelessWidget {
  ArticleReading({Key? key}) : super(key: key);
  String textValue =
      'That marked a turnaround from last year, when the social network reported a decline in users for the first time.\n The drop wiped billions from the firms market value.\n Since executives disclosed the fall in February, the firms share price has nearly halved.But shares jumped 19% in after-hours trade on Wednesday.';

  String title = 'Four Things Everyone Needs To Know';
  
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        debugShowCheckedModeBanner: false,
        home: Builder(builder: (BuildContext context) {
          return Scaffold(
            backgroundColor: scaffoldBackground,
            floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
            body: SafeArea(
              child: Column(
                children: [
                  SingleChildScrollView(
                    scrollDirection: Axis.vertical,
                    child: Column(
                      children: [
                        Padding(
                          padding: EdgeInsets.fromLTRB(
                              UIConverter.getComponentWidth(context, 40),
                              UIConverter.getComponentHeight(context, 35),
                              UIConverter.getComponentWidth(context, 32),
                              UIConverter.getComponentHeight(context, 20)),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: const [
                                  Icon(Icons.arrow_back),
                                  Icon(Icons.more_horiz)
                                ],
                              ),
                              SizedBox(
                                height: UIConverter.getComponentHeight(context, 32),
                              ),
                              Text(
                                title,
                                style: const TextStyle(
                                  color: primaryTextColor,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 25,
                                ),
                              ),
                              SizedBox(
                                height: UIConverter.getComponentHeight(context, 32),
                              ),
                               ArticleProfile(),
                            ],
                          ),
                        ),
                        Container(
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(20),
                          ),
                          height: UIConverter.getComponentHeight(context, 165),
                          width: double.infinity,
                          child: ClipRRect(
                            borderRadius: const BorderRadius.only(
                                topLeft: Radius.circular(20),
                                topRight: Radius.circular(20)),
                            child: Image.asset(
                              articleReadingFasionImage3,
                              width: double.infinity,
                              fit: BoxFit.cover,
                            ),
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.fromLTRB(UIConverter.getComponentWidth(context, 21),
                              UIConverter.getComponentHeight(context, 21),
                              UIConverter.getComponentWidth(context, 23),
                              0),
                          child: Text(
                            textValue,
                            maxLines: null,
                            style: TextStyle(
                                color: secondaryTextColor,
                                height: 1.5,
                                fontSize: UIConverter.getComponentWidth(context, 15)),
                          ),
                        ),
                      ],
                    ),
                  ),
                  // FloatingActionButton: like_button(),
                ],
              ),
              //
            ),
            floatingActionButton: LikeButton(),
          );
        }));
  }
}
