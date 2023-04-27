import 'package:dark_knights/core/utils/colors.dart';
import 'package:dark_knights/core/utils/converter.dart';
import 'package:dark_knights/features/example/presentation/widgets/floating_action_button.dart';
import 'package:dark_knights/features/example/presentation/widgets/header.dart';
import 'package:dark_knights/features/example/presentation/widgets/header_icons.dart';
import 'package:dark_knights/features/example/presentation/widgets/post.dart';
import 'package:flutter/material.dart';

class ArticleReadingPage extends StatefulWidget {
  const ArticleReadingPage({super.key});

  @override
  State<ArticleReadingPage> createState() => _ArticleReadingPageState();
}

class _ArticleReadingPageState extends State<ArticleReadingPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(
          children: [
            headerIcons(context),
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    header(context),
                    post(context),
                  ],
                ),
              ),
            ),
          ],
        ),
        floatingActionButton: floatingActionButton(context));
  }
}
