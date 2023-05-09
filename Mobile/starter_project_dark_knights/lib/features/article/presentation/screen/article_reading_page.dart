import 'package:dark_knights/features/article%20reading/presentation/widgets/Article_Like_Button.dart';
import 'package:dark_knights/features/article%20reading/presentation/widgets/Article_Post.dart';
import 'package:dark_knights/features/article%20reading/presentation/widgets/Header.dart';
import 'package:dark_knights/features/article%20reading/presentation/widgets/Header_Icons.dart';
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
            const HeaderIconButtons(),
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: const [Header(), ArticlePost()],
                ),
              ),
            ),
          ],
        ),
        floatingActionButton: const ArticleLikeButton());
  }
}
