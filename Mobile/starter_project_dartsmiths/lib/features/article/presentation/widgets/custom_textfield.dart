import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import '../../../../core/utils/colors.dart';
import 'package:dartsmiths/core/utils/article_page_styles.dart';


class CustomTextField extends StatelessWidget {
  TextEditingController textEditingController ;
  final String placeholder;
  final int maxHintLine;
  final int maxLineCount;
  Function textFormFunction;
  CustomTextField({required this.maxHintLine, required this.maxLineCount, required this.placeholder, required this.textEditingController, required this.textFormFunction});

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: textEditingController,
      maxLines: maxLineCount, // Set this
      keyboardType: TextInputType.multiline,
      decoration: InputDecoration(
          fillColor: contentBgColor,
          border: const OutlineInputBorder(
              borderRadius: BorderRadius.all(Radius.circular(15))),
          hintText: (placeholder), //hint text
          hintStyle: postArticleTheme.bodyLarge, //hint text style
          hintMaxLines: maxHintLine, //hint text maximum lines
          hintTextDirection:
              TextDirection.ltr //hint text direction, current is RTL
          ),
      onTap: () => {textFormFunction(textEditingController.text)},
    );
  }
}
