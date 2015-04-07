using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.SpecializedProperties;
using Ignobilis.Models.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ignobilis.Test
{
    [TestClass]
    public class BusinessLogicTest
    {
        [TestInitialize]
        public void MockEpiServerDependencies()
        {
            //Create a mock repository - slack
            var mockRepository = new Mock<IContentRepository>();

            var pageStart   = new IB_BasePage {Headline = "Start"};
            var page1       = new IB_BasePage {Headline = "Page 1"};
            var page2       = new IB_BasePage {Headline = "Page 2"};
            var page3       = new IB_BasePage {Headline = "Page 3"};
            var page4       = new IB_BasePage {Headline = "Page 4"};
            var page5       = new IB_BasePage {Headline = "Page 5"};
            var page11      = new IB_BasePage {Headline = "Page 1_1"};
            var page12      = new IB_BasePage {Headline = "Page 1_2"};
            var page13      = new IB_BasePage {Headline = "Page 1_3"};
            var page14      = new IB_BasePage {Headline = "Page 1_4"};
            var page15      = new IB_BasePage {Headline = "Page 1_5"};
            var page21      = new IB_BasePage {Headline = "Page 2_1"};
            var page22      = new IB_BasePage {Headline = "Page 2_2"};
            var page23      = new IB_BasePage {Headline = "Page 2_3"};
            var page24      = new IB_BasePage {Headline = "Page 2_4"};
            var page25      = new IB_BasePage {Headline = "Page 2_5"};

            var pageSettings = new IB_SettingsPage
            {
                MainMenu = new LinkItemCollection
                {
                    new LinkItem { Text = page1.PageName, Href = page1.LinkURL },
                    new LinkItem { Text = page2.PageName, Href = page2.LinkURL },
                    new LinkItem { Text = page3.PageName, Href = page3.LinkURL },
                    new LinkItem { Text = page4.PageName, Href = page4.LinkURL },
                    new LinkItem { Text = page5.PageName, Href = page5.LinkURL }
                }
            };

            var ibBasePagesRoot = new List<IB_BasePage>{page1,page2,page3,page4,page5,};
            var ibBasePagesChilds1 = new List<IB_BasePage>{page11,page12,page13,page14,page15};
            var ibBasePagesChilds2 = new List<IB_BasePage>{page21,page22,page23,page24,page25};
            var ancestors1 = new List<IB_BasePage>{pageStart};
            var ancestors2 = new List<IB_BasePage>{pageStart,page1};
            var ancestors3 = new List<IB_BasePage>{pageStart,page2};

            //sätter upp att de är tillgängliga i menyn
            pageStart.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page1.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page2.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page3.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page11.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page12.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page13.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page14.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page15.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page21.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page22.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page23.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page24.Property.Add("PageVisibleInMenu", new PropertyBoolean(true));
            page25.Property.Add("PageVisibleInMenu", new PropertyBoolean(false));

            pageStart.Property.Add("PageLink", new PropertyPageReference(1337));
            page1.Property.Add("PageLink", new PropertyPageReference(1));
            page2.Property.Add("PageLink", new PropertyPageReference(2));
            page3.Property.Add("PageLink", new PropertyPageReference(3));
            page4.Property.Add("PageLink", new PropertyPageReference(4));
            page5.Property.Add("PageLink", new PropertyPageReference(5));
            page11.Property.Add("PageLink", new PropertyPageReference(11));
            page12.Property.Add("PageLink", new PropertyPageReference(12));
            page13.Property.Add("PageLink", new PropertyPageReference(13));
            page14.Property.Add("PageLink", new PropertyPageReference(14));
            page15.Property.Add("PageLink", new PropertyPageReference(15));
            page21.Property.Add("PageLink", new PropertyPageReference(21));
            page22.Property.Add("PageLink", new PropertyPageReference(22));
            page23.Property.Add("PageLink", new PropertyPageReference(23));
            page24.Property.Add("PageLink", new PropertyPageReference(24));
            page25.Property.Add("PageLink", new PropertyPageReference(25));
            
            mockRepository.Setup(r => r.GetChildren<PageData>(new ContentReference(1337))).Returns(ibBasePagesRoot);
            mockRepository.Setup(r => r.GetChildren<PageData>(new ContentReference(1))).Returns(ibBasePagesChilds1);
            mockRepository.Setup(r => r.GetChildren<PageData>(new ContentReference(2))).Returns(ibBasePagesChilds2);
            mockRepository.Setup(r => r.Get<IContent>(new ContentReference(1))).Returns(page1);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(1))).Returns(ancestors1);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(2))).Returns(ancestors1);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(3))).Returns(ancestors1);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(11))).Returns(ancestors2);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(12))).Returns(ancestors2);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(13))).Returns(ancestors2);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(14))).Returns(ancestors2);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(15))).Returns(ancestors2);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(21))).Returns(ancestors3);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(22))).Returns(ancestors3);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(23))).Returns(ancestors3);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(24))).Returns(ancestors3);
            mockRepository.Setup(r => r.GetAncestors(new ContentReference(25))).Returns(ancestors3);

            mockRepository.Setup(r => r.GetChildren<PageData>(ContentReference.EmptyReference)).Returns
                (new List<IB_BasePage>());
            
            var mockLocator = new Mock<IServiceLocator>();

            // Setup the service locator to return our mock repository when an IContentRepository is requested
            mockLocator.Setup(r => r.GetInstance<IContentRepository>()).Returns(
                mockRepository.Object);

            ServiceLocator.SetLocator(mockLocator.Object);
        }


        [TestMethod]
        public void RecursiveMenu_Loadingfromrootwithpageintree_Returns7pages()
        {
            // Arrange
            var recursiveMenus = IgnobilisService.Instance.Settings.Functionality.Menu;
            // Act
            var menus = recursiveMenus.Load(new PageReference(1337), new PageReference(24));
            // Assert
            Assert.IsTrue(menus.Count == 7);
        }

        [TestMethod]
        public void RecursiveMenu_Loadingfromchildtreepagenotintree_Returns5pages()
        {
            // Arrange
            var recursiveMenus = IgnobilisService.Instance.Settings.Functionality.Menu;
            // Act
            var menus = recursiveMenus.Load(new PageReference(1), new PageReference(24));
            // Assert
            Assert.IsTrue(menus.Count == 5);
        }

        [TestMethod]
        public void RecursiveMenu_Loadingfromchildtreesettingonepagenotvisibleinmenu_Returns4pages()
        {
            // Arrange
            var pageDatas = ServiceLocator.Current.GetInstance<IContentRepository>().GetChildren<PageData>(new ContentReference(1)).ToList();            
            var recursiveMenus = IgnobilisService.Instance.Settings.Functionality.Menu;
            // Act
            pageDatas[0].Property["PageVisibleInMenu"].Value = false;
            var menus = recursiveMenus.Load(new PageReference(1), new PageReference(24));
            // Assert
            Assert.IsTrue(menus.Count == 4);
        }

        [TestMethod]
        public void RecursiveMenu_Emptypagereference_Returns0pages()
        {
            // Arrange
            var recursiveMenus = IgnobilisService.Instance.Settings.Functionality.Menu;
            // Act
            var menus = recursiveMenus.Load(PageReference.EmptyReference, new PageReference(24));
            // Assert
            Assert.IsTrue(menus.Count == 0);
        }

        [TestMethod]
        public void RecursiveMenu_Activepagenonexistant_Returns5pages()
        {
            // Arrange
            var recursiveMenus = IgnobilisService.Instance.Settings.Functionality.Menu;
            // Act
            var menus = recursiveMenus.Load(new PageReference(1), new PageReference(1000));
            // Assert
            Assert.IsTrue(menus.Count == 5);
        }

        [TestMethod]
        public void BreadCrumb_Loadfromonedown_Returns2Pages()
        {
            // Arrange
            var breadCrumb = IgnobilisService.Instance.Settings.Functionality.BreadCrumb;
            // Act
            var contents = breadCrumb.Load(new PageReference(1));            
            // Assert
            Assert.IsTrue(contents.Count == 2);
        }

        [TestMethod]
        public void BreadCrumb_Emptypagereference_Returns0Pages()
        {
            // Arrange
            var breadCrumb = IgnobilisService.Instance.Settings.Functionality.BreadCrumb;
            // Act
            var contents = breadCrumb.Load(PageReference.EmptyReference);
            // Assert
            Assert.IsTrue(contents.Count == 0);
        }

        [TestMethod]
        public void LinkList_Strings_ReturnsCorrectType()
        {
            // Arrange
            Type LinkListType;
            IgnobilisService.Instance.Settings.Functionality.ContentLists.TryGetValue(Business.Global.Strings.LinkList, out LinkListType);

            // Act
            var Name = LinkListType.Name;

            //Assert
            Equals(Name == "LinkList");
        }

        [TestMethod]
        public void LinkList_EmptyCollection_ReturnsFalse()
        {
            // Arrange
            Type LinkListType;
            IgnobilisService.Instance.Settings.Functionality.ContentLists.TryGetValue(Business.Global.Strings.LinkList, out LinkListType);
            var linkList = (Business.Functionality.LinkList)Activator.CreateInstance(LinkListType);

            // Act
            var IsInit = linkList.Init(new LinkItemCollection());

            // Assert
            Assert.IsFalse(IsInit);
        }

        [TestMethod]
        public void ListContentTree_Strings_ReturnsCorrectType()
        {
            // Arrange
            Type ListContentTree;
            IgnobilisService.Instance.Settings.Functionality.ContentLists.TryGetValue(Business.Global.Strings.ListContentTree, out ListContentTree);

            // Act
            var Name = ListContentTree.Name;

            //Assert
            Equals(Name == "ListContentTree");
        }

        [TestMethod]
        public void ListContentTree_EmptyCollection_ReturnsFalse()
        {
            // Arrange
            Type ListContentTree;
            IgnobilisService.Instance.Settings.Functionality.ContentLists.TryGetValue(Business.Global.Strings.ListContentTree, out ListContentTree);
            var listContentTree = (Business.Functionality.ListContentTree)Activator.CreateInstance(ListContentTree);

            // Act
            var IsInit = listContentTree.Init(new LinkItemCollection());

            // Assert
            Assert.IsFalse(IsInit);
        }
    }
}
