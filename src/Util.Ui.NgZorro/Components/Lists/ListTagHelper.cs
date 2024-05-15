﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists; 

/// <summary>
/// 列表,生成的标签为&lt;nz-list>&lt;/nz-list>
/// </summary>
[HtmlTargetElement( "util-list" )]
public class ListTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzBordered],是否显示边框,默认值: false
    /// </summary>
    public string Bordered { get; set; }
    /// <summary>
    /// nzHeader,列表头部,类型: string
    /// </summary>
    public string Header { get; set; }
    /// <summary>
    /// [nzHeader],列表头部,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindHeader { get; set; }
    /// <summary>
    /// nzFooter,列表底部,类型: string
    /// </summary>
    public string Footer { get; set; }
    /// <summary>
    /// [nzFooter],列表底部,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindFooter { get; set; }
    /// <summary>
    /// nzItemLayout,列表项布局方式,可选值: 'vertical' | 'horizontal',默认值: 'horizontal'
    /// </summary>
    public ListItemLayout ItemLayout { get; set; }
    /// <summary>
    /// [nzItemLayout],列表项布局方式,可选值: 'vertical' | 'horizontal',默认值: 'horizontal'
    /// </summary>
    public string BindItemLayout { get; set; }
    /// <summary>
    /// [nzLoading],是否加载状态,默认值: false
    /// </summary>
    public string Loading { get; set; }
    /// <summary>
    /// nzSize,列表大小,可选值: 'large' | 'small' | 'default',默认值: 'default'
    /// </summary>
    public ListSize Size { get; set; }
    /// <summary>
    /// [nzSize],列表大小,可选值: 'large' | 'small' | 'default',默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzSplit],是否显示分割线,默认值: true
    /// </summary>
    public string Split { get; set; }
    /// <summary>
    /// [nzGrid],是否支持栅格列表,默认值: false
    /// </summary>
    public string Grid { get; set; }
    /// <summary>
    /// [nzDataSource],设置数据源
    /// </summary>
    public string Datasource { get; set; }
    /// <summary>
    /// [nzRenderItem],设置自定义项模板,类型: TemplateRef&lt;{ $implicit: NzSafeAny; index: number }>
    /// </summary>
    public string RenderItem { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ListRender( config );
    }
}