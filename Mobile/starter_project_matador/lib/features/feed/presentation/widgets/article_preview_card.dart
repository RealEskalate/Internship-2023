import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';

class ArticlePreviewCard extends StatelessWidget {
  const ArticlePreviewCard({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: ListView(
        children: [
          buildCard(context),
          SizedBox(
            height: convertPixelToScreenHeight(context, 25),
          ),
          buildCard(context)
        ],
      ),
    );
  }

  Widget buildCard(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
          color: Colors.white,
          borderRadius:
              BorderRadius.circular(convertPixelToScreenHeight(context, 10)),
          boxShadow: const [
            homePageFirstShadowStyle,
            homePageSecondShadowStyle
          ]),
      child: Padding(
        padding: EdgeInsets.only(
            left: 15, right: 15, top: convertPixelToScreenHeight(context, 25)),
        child: SizedBox(
          height: convertPixelToScreenHeight(context, 240),
          child: Column(
            children: [
              Expanded(
                flex: 3,
                child: Row(
                  children: [
                    Expanded(
                      flex: 1,
                      child: Stack(
                        children: [
                          Padding(
                            padding: const EdgeInsets.only(right: 15),
                            child: Container(
                              decoration: BoxDecoration(
                                image: const DecorationImage(
                                    fit: BoxFit.cover,
                                    image: AssetImage(
                                        "assets/images/card_image.jpg")),
                                borderRadius: BorderRadius.circular(9),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Expanded(
                      flex: 1,
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Expanded(
                            child: Text(
                              "Students should work on improving their writing skill"
                                  .toUpperCase(),
                              style: cardHeaderTextStyle,
                            ),
                          ),
                          Container(
                              margin: const EdgeInsets.symmetric(vertical: 8.0),
                              width: convertPixelToScreenWidth(context, 71),
                              height: convertPixelToScreenHeight(context, 21),
                              decoration: BoxDecoration(
                                  color: cardTagColor,
                                  borderRadius: BorderRadius.circular(3)),
                              child: const Center(
                                child: Text(
                                  "Education",
                                  style: cardTagTextStyle,
                                ),
                              )),
                          const Text(
                            "by Joe Doe",
                            style: cardAuthorTextStyle,
                          ),
                        ],
                      ),
                    )
                  ],
                ),
              ),
              Expanded(
                flex: 1,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: const [
                    Text(
                      "June 12 2022",
                      style: cardDateTextStyle,
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
