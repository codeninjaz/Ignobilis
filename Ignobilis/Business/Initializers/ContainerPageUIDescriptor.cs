using EPiServer.Shell;
using Ignobilis.Models.Pages;

namespace Ignobilis.Business.Initializers
{
    [UIDescriptorRegistration]
    public class ContainerPageUIDescriptor : UIDescriptor<IB_ContainerPage> 
    {
        public ContainerPageUIDescriptor() : base(ContentTypeCssClassNames.Container)
        {
            DefaultView = CmsViewNames.AllPropertiesView;            
        } 
    }
}