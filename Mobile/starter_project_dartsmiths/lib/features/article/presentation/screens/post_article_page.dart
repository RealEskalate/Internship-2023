import 'package:flutter/material.dart';
import 'package:dartsmiths/core/utils/article_page_styles.dart';
import '../widgets/chips_builder.dart';
import '../widgets/custom_textfield.dart';

import '../../../../core/utils/colors.dart';

class PostArticlePage extends StatefulWidget {
  const PostArticlePage({super.key});

  @override
  State<PostArticlePage> createState() => _PostArticlePageState();
}

class _PostArticlePageState extends State<PostArticlePage> {
  _PostArticlePageState();
  TextEditingController controllerTags = TextEditingController();
  TextEditingController controllerTitle = TextEditingController();
  TextEditingController controllerSubTitle = TextEditingController();
  TextEditingController controllerContent = TextEditingController();
  List chipList = [];

  void _addChip(String chipText) {
    setState(() {
      chipList.add(chipText);
      controllerTags.clear();
    });
  }

  void removeChips(String chipText) {
    setState(() {
      chipList.remove(chipText);
    });
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    double windowHeight = size.height;
    double windowWidth = size.width;

    return Scaffold(
      body: SingleChildScrollView(
          physics: const BouncingScrollPhysics(),
          padding: EdgeInsets.fromLTRB(windowWidth * 0.1, windowHeight * 0.07,
              windowWidth * 0.1, windowHeight * 0.07),
          child: ConstrainedBox(
            constraints: BoxConstraints(
              minHeight: windowHeight,
            ),
            child: Form(
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                          width: windowWidth * 0.1,
                          height: windowWidth * 0.1,
                          decoration: const BoxDecoration(
                              borderRadius:
                                  BorderRadius.all(Radius.circular(11)),
                              color: backIconBgColor),
                          child: const Icon(Icons.keyboard_arrow_left,
                              color: backIconColor)),
                      Text(
                        "Post Article",
                        style: postArticleTheme.displayLarge,
                      )
                    ],
                  ),
                  SizedBox(
                    height: windowHeight * 0.064,
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      CustomTextField(
                          maxHintLine: 2,
                          maxLineCount: 1,
                          placeholder: "Add title",
                          textEditingController: controllerTitle,
                          textFormFunction: () {}),
                      CustomTextField(
                          maxHintLine: 2,
                          maxLineCount: 1,
                          placeholder: "Add subtitle",
                          textEditingController: controllerSubTitle,
                          textFormFunction: () {}),
                      TextField(
                        controller: controllerTags,
                        decoration: InputDecoration(
                          suffixIcon: GestureDetector(
                            onTap: () => {_addChip(controllerTags.text)},
                            child: const Icon(
                              Icons.add,
                              textDirection: TextDirection.rtl,
                              color: darkPrimaryColorGradient,
                            ),
                          ),

                          hintText: ("Add tags"), //hint text
                          //hint text style
                          hintStyle:
                              postArticleTheme.bodyLarge, //hint text style

                          hintMaxLines: 2, //hint text maximum lines
                          hintTextDirection: TextDirection.ltr,

                          //hint text direction, current is RTL
                        ),
                      ),
                      Text(
                        "add as many tags as you want",
                        style: postArticleTheme.bodySmall, //hint text style
                      ),
                      SizedBox(
                        height: windowHeight * 0.02,
                      ),
                      Wrap(
                        spacing: 6.0,
                        runSpacing: 6.0,
                        children: chipList
                            .map((e) =>
                                BuildChip(label: e, removeChips: removeChips))
                            .toList(),
                      ),
                      SizedBox(
                        height: windowHeight * 0.043,
                      ),
                      CustomTextField(
                          maxHintLine: 15,
                          maxLineCount: 15,
                          placeholder: "Article Content",
                          textEditingController: controllerContent,
                          textFormFunction: () {}),
                      SizedBox(
                        height: windowHeight * 0.09,
                      ),
                      Center(
                        child: Container(
                          decoration: const BoxDecoration(
                            color: darkPrimaryColorGradient,
                            borderRadius: BorderRadius.all(
                              Radius.circular(15),
                            ),
                          ),
                          child: TextButton(
                            style: ButtonStyle(
                              padding: MaterialStateProperty.all(
                                  const EdgeInsets.fromLTRB(27, 7, 27, 7)),
                            ),
                            child: Text(
                              'Publish',
                              style: postArticleTheme.bodyMedium,
                            ),
                            onPressed: () => {},
                          ),
                        ),
                      )
                    ],
                  )
                ],
              ),
            ),
          )),
    );
  }
}
